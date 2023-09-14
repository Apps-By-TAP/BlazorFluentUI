
export function canExpandDown(guid) {
    //var ele = document.getElementById(guid);
    //var rect = ele.getBoundingClientRect();
    //const realHeight = window.innerHeight + window.scrollY;

    //alert(window.innerHeight + " " + window.scrollY);
    //alert(ele.offsetTop + rect.height + " < " + realHeight);
    //return (ele.offsetTop + rect.height) < realHeight;


    var ele = document.getElementById(guid);
    var rect = ele.getBoundingClientRect();
    const realHeight = window.innerHeight;
    var result = (rect.y + rect.height) < realHeight;
    return result;
}

export function getNewTopLocation(guid) {
    var ele = document.getElementById(guid);
    var rect = ele.parentNode.getBoundingClientRect();
    var top = rect.top + window.scrollY;
    var result = top + 3 - ele.getBoundingClientRect().height;
    return result;
}