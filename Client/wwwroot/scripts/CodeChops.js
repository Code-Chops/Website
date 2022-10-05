// Format and beautify code for display.
window.highlightCode = () => {
    document.querySelectorAll("pre code").forEach((element) => {
        hljs.highlightElement(element);
    });
}

// Remove splash, attach logo, and dissolve overlay.
// Gets fired from .NET.
window.removeSplash = () => {
    const logo = document.getElementById("logo");
    logo.classList.add("attachedLogo");
    logo.classList.remove("splashLogo");

    const clickableLogo = document.getElementById("clickableLogo");
    clickableLogo.href = "/";

    const overlay = document.getElementById("overlay");
    overlay.classList.add("dissolveOverlay");
}

window.blazorCulture = {
    get: () => window.localStorage["BlazorCulture"]
        ? window.localStorage["BlazorCulture"]
        : navigator.language.substring(0, 2) || "en",
    set: (value) => window.localStorage["BlazorCulture"] = value
}

window.blazorColorMode = {
    get: () => window.localStorage["BlazorColorMode"]
        ? window.localStorage["BlazorColorMode"]
        : (window.matchMedia && window.matchMedia('(prefers-color-scheme: light)').matches) ? "LightMode" : "DarkMode",
    set: (value) => window.localStorage["BlazorColorMode"] = value
}

document.documentElement.style.setProperty("--overlay-background-color", window.blazorColorMode.get() === "DarkMode" ? "#1e1e1e" : "white");

window.loadImageAndShow = (imageId, elementToShowId) => {
    const element = document.getElementById(imageId);
    element.onload = () => {
        const elementToShow = document.getElementById(elementToShowId);
        elementToShow.classList.add("animation");
        elementToShow.style.visibility = "visible";
    };
}