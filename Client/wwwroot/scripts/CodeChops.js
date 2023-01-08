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

window.addThumbnailVisualizations = (imageId, thumbnailId) => {
    const image = document.getElementById(imageId);

    image.onload = () => {
        const elementToShow = document.getElementById(imageId);
        elementToShow.style.visibility = "visible";

        const main = document.getElementById("main");

        main.addEventListener("scroll", _ => {
            if (!isTouchDevice())
                return;

            const thumbnail = document.getElementById(thumbnailId);
            const verticalCenter = main.scrollTop + Math.max(document.documentElement.clientHeight || 0, window.innerHeight || 0) / 2;
            const rect = thumbnail.getBoundingClientRect();
            const elementCenter = main.scrollTop + rect.top + rect.height / 2;
            const value = Math.abs(verticalCenter - elementCenter) / verticalCenter;

            const text = thumbnail.childNodes[0];
            const opacity = 1 - value - value * 8;
            text.style.opacity = opacity.toString();

            let brightness = value * 8;
            if (brightness < .2) brightness = .2;
            if (brightness > 1) brightness = 1;
            image.style.filter = "brightness(" + brightness + ")";
        });
    };
}

function isTouchDevice() {
    return (('ontouchstart' in window) ||
        (navigator.maxTouchPoints > 0) ||
        (navigator.msMaxTouchPoints > 0));
}
