
export function canExpandDown(guid) {
    var ele = document.getElementById(guid);
    var rect = ele.getBoundingClientRect();
    const realHeight = window.innerHeight;
    return rect.y + rect.height < realHeight;
}

export function getNewTopLocation(guid) {
    var ele = document.getElementById(guid);
    var parentRect = ele.parentNode.getBoundingClientRect();
    var eleRect = ele.getBoundingClientRect();

    return parentRect.y + 3 - eleRect.height;
}