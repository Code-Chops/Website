window.copyElement = (sourceId, copyId, preloadCrossfade) =>
{
    const sourceElement = document.getElementById(sourceId);
    if (sourceElement == null) return;
    
    const sourceHtml = sourceElement?.firstChild?.outerHTML;
    if (sourceHtml == null) return;

    if (preloadCrossfade) {
        for (let element of getDescendantNodes(sourceElement)) {
            if (element.id === "") continue;
            
            element.removeEventListener(
                "scroll",
                e => onScroll(e, copyId, element.id),
                { passive: true }
            );
            element.addEventListener(
                "scroll",
                e => onScroll(e, copyId, element.id),
                { passive: true }
            );
        }
    }
    
    return sourceHtml;
}

const getDescendantNodes = (node, all = []) => {
    all.push(...node.childNodes);
    for (const child of node.childNodes)
        getDescendantNodes(child, all);
    return all;
}

const onScroll = (e, copyId, scrollElementId) => {
    if (e.currentTarget == null || e.currentTarget.scrollTop === 0) {
        return;
    }
    
    const copyElement = document.getElementById(copyId);

    if (copyElement == null) {
        return;
    }

    const scrollElement = copyElement.querySelector('#'+ scrollElementId);
 
    scrollElement.scrollTop = e.currentTarget.scrollTop;
    scrollElement.scrollLeft = e.currentTarget.scrollLeft;
}