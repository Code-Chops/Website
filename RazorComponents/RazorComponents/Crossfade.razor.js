window.copyElement = (sourceId, copyId, preloadCrossfade) =>
{
    const sourceElement = document.getElementById(sourceId);
    if (sourceElement == null)
        return;
    
    const node = sourceElement?.firstChild;
    const sourceHtml = node?.outerHTML;
    if (sourceHtml == null)
        return;

    if (preloadCrossfade) {
        for (let element of getDescendantNodes(sourceElement)) {
            if (element.id === "") continue;
        
            element.removeEventListener(
                "scroll",
                e => scroll(e.currentTarget, copyId, element.id),
                { passive: true }
            );
            element.addEventListener(
                "scroll",
                e => scroll(e.currentTarget, copyId, element.id),
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

const scroll = (element, copyId, scrollElementId) => {
    if (element == null || element.scrollTop === 0)
        return;

    const copyElement = document.getElementById(copyId);

    if (copyElement == null)
        return;

    const scrollElement = copyElement.querySelector('#'+ scrollElementId);
    
    if (scrollElement == null)
        return;
    
    scrollElement.scrollTop = element.scrollTop;
    scrollElement.scrollLeft = element.scrollLeft;
}