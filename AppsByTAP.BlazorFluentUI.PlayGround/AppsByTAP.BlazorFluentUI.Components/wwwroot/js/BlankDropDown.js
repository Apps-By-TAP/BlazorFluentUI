
export function canExpandDown(guid) {
    var ele = document.getElementById(guid);
    var rect = ele.getBoundingClientRect();
    const realHeight = window.innerHeight + window.scrollY;
    return (ele.offsetTop + rect.height) < realHeight;
}

export function getNewTopLocation(guid) {
    var ele = document.getElementById(guid);

    return ele.parentNode.offsetTop + 3 - ele.getBoundingClientRect().height;
}