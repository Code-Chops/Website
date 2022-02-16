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
        fireEvent(element, "click");
	}
}

// Fire event.
function fireEvent(element, eventType) {
    document.removeEventListener("click", onClick);

    if (element.fireEvent) {
        element.fireEvent("on" + eventType);
    } else {
        const eventObject = document.createEvent("Events");
        eventObject.initEvent(eventType, true, false);
        element.dispatchEvent(eventObject);
    }

    document.addEventListener("click", onClick);
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

    document.removeEventListener("click", onClick);
}

function showBanner(text) {
    console.log(text);
}

window.blazorCulture = {
    get: () => window.localStorage["BlazorCulture"] ? window.localStorage["BlazorCulture"] : navigator.language || navigator.userLanguage || "en",
    set: (value) => window.localStorage["BlazorCulture"] = value
};

window.blazorDarkMode = {
    get: () => window.localStorage["BlazorDarkMode"] && window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches,
    set: (value) => window.localStorage["BlazorDarkMode"] = value
};