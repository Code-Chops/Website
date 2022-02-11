// Format and beautify code.
window.highlightCode = () => {
    document.querySelectorAll("pre code").forEach((element) => {
        hljs.highlightElement(element);
    });
}

// Register the click on the splash screen.
document.addEventListener("click", onClick);

// Fire click event and so .NET registers it.
function onClick(doc, e) {
    const element = document.getElementById("clickOverlay");
    if (element) {
        document.removeEventListener("click", onClick);
        fireEvent(element, "click");
	}
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
// Remove click event listener.
window.onSplashClick = () => {
    const logo = document.getElementById("logo");
    logo.classList.add("attachedLogo");
    logo.classList.remove("splashLogo");

    const overlay = document.getElementById("overlay");
    overlay.classList.add("dissolveOverlay");
}

function showBanner(text) {
    console.log(text);
}