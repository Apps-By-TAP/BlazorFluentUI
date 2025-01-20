export function registerEvent(targetID, css) {

    var element = document.getElementById(targetID);

    if (element) {

        var style = document.createElement('style');
        style.innerHTML = "{" + css + "}";
        document.head.appendChild(style);

        element.addEventListener('click', function () {
            this.classList.add('loading-' + targetID);
            this.style.pointerEvents = 'none';
        });
    }
}