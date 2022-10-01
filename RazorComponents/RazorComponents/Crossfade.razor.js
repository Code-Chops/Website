window.copyElement = (id) =>
{
    const element = document.getElementById(id).firstChild.outerHTML;
    return element;
}