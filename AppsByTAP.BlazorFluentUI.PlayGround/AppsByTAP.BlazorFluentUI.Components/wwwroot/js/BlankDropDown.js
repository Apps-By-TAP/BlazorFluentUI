
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
    var ctrl = ele.parentNode.querySelector(".dropDownCtrl") || ele.parentNode;
    var ctrlRect = ctrl.getBoundingClientRect();

    // `top` is relative to the containing block's padding box (the .dropDownWrapper),
    // so subtract its viewport position plus any border/padding offsets.
    var container = ele.offsetParent || ctrl;
    var containerRect = container.getBoundingClientRect();
    var cs = window.getComputedStyle(container);
    var containerTop = containerRect.top + parseFloat(cs.borderTopWidth) + parseFloat(cs.paddingTop);

    // Keep the panel's bottom edge 3px past the control's top edge.
    var result = (ctrlRect.top + 3 - ele.getBoundingClientRect().height) - containerTop;
    return result;
}