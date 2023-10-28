export function getNewLeftLocation(guid) {
    var div = document.getElementById(guid);

    // Get the width of the div
    var divWidth = div.offsetWidth;

    // Get the width of the viewport (the visible part of the screen)
    var viewportWidth = window.innerWidth;

    // Get the right edge position of the div
    var divRight = div.getBoundingClientRect().right;

    // Calculate how much the div is off the right side of the screen
    var offScreenAmount = divRight - viewportWidth;

    // Get the scrollbar width
    var scrollbarWidth = window.innerWidth - document.documentElement.clientWidth;

    // Subtract the scrollbar width from offScreenAmount
    offScreenAmount += scrollbarWidth + 2;

    if (offScreenAmount <= 0) {
        return 0;
    }

    // Return a negative value indicating how much to move the div to the left
    return -offScreenAmount;
}