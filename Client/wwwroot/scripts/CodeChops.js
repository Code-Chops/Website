// Format and beautify code for display.
window.highlightCode = () => {
    document.querySelectorAll("pre code").forEach((element) => {
        hljs.highlightElement(element);
    });
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
        if (!isTouchDevice())
            return;

        const thumbnail = document.getElementById(thumbnailId);
        const text = thumbnail.childNodes[0];

        image.style.transition = "unset";
        text.style.transition = "unset";


        main.addEventListener("scroll", _ => {
            const mainBounds = main.getBoundingClientRect();
            const verticalCenter = mainBounds.top + mainBounds.height / 2;
            const rect = thumbnail.getBoundingClientRect();
            const elementCenter = mainBounds.top + rect.top + rect.height / 2;
            const value = Math.abs(verticalCenter - elementCenter) / verticalCenter;

            let textOpacity = (1.2 - value * 3);
            if (textOpacity < 0) textOpacity = 0;
            if (textOpacity > 1) textOpacity = 1;
            text.style.opacity = textOpacity.toString();

            let imageBrightness = value;
            if (imageBrightness < .2) imageBrightness = .2;
            if (imageBrightness > 1) imageBrightness = 1;
            image.style.filter = "brightness(" + imageBrightness + ")";
        });
    };
}

function isTouchDevice() {
    return (('ontouchstart' in window) ||
        (navigator.maxTouchPoints > 0) ||
        (navigator.msMaxTouchPoints > 0));
}
