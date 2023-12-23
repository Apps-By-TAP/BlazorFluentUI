let dotnetRef = {};
let guid = "";
let targetID = "";

export function registerResizeCallback(callbackObj, id, tid) {
    dotnetRef = callbackObj;
    guid = id;
    targetID = tid;
}

export function getNewLeftLocation(guid, targetDiv) {
    var div = document.getElementById(guid);
    var targetDiv = document.getElementById(targetDiv);

    // Get the width of the div
    var divWidth = div.offsetWidth;

    // Get the width of the viewport (the visible part of the screen)
    var viewportWidth = window.innerWidth;

    //// Get the right edge position of the div
    //var divRight = div.getBoundingClientRect().right;

    // Calculate how much the div is off the right side of the screen
    var offScreenAmount = (targetDiv.getBoundingClientRect().left + divWidth) - viewportWidth;

    // Get the scrollbar width
    var scrollbarWidth = window.innerWidth - document.documentElement.clientWidth;

    // Subtract the scrollbar width from offScreenAmount
    offScreenAmount += scrollbarWidth + 2;

    if (offScreenAmount <= 0) {
        return 0;
    }

    // Return a negative value indicating how much to move the div to the left
    return targetDiv.getBoundingClientRect().left - offScreenAmount;
}

window.addEventListener('resize', () => {
    var left = getNewLeftLocation(guid, targetID);
    dotnetRef.invokeMethodAsync("LeftChanged", left);
});