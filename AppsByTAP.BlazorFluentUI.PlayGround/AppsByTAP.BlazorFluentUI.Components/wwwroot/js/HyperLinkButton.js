export function registerEvent(targetID) {
    document.getElementById(targetID).addEventListener('click', function () {
        this.classList.add('loading');
        this.style.pointerEvents = 'none';
    });
}