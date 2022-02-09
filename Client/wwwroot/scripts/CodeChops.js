// Format and beautify code.
window.highlightCode = () => {
    document.querySelectorAll("pre code").forEach((element) => {
        hljs.highlightElement(element);
    });
}

// Register the click on the splash screen.
document.addEventListener("click", onClick);

// Remove click event listener. Fire click event and so .NET registers it.
function onClick(doc, e) {
    document.removeEventListener("click", onClick);
    const element = document.getElementById("clickOverlay");
    fireEvent(element, "click");
}

// Fire event.
function fireEvent(element, eventType) {
    if (element.fireEvent) {
        element.fireEvent("on" + eventType);
    } else {
        const eventObject = document.createEvent("Events");
        eventObject.initEvent(eventType, true, false);
        element.dispatchEvent(eventObject);
    }
}

// Remove splash, attach logo, and dissolve overlay.
// Gets fired from .NET.
window.onSplashClick = () => {
    const logo = document.getElementById("logo");
    logo.classList.add("attachedLogo");
    logo.classList.remove("splashLogo");

    const overlay = document.getElementById("overlay");
    overlay.classList.add("dissolveOverlay");
}