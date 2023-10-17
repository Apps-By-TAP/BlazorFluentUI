let cache = {};

export function Register(guid, dotNetRef) {
    cache[guid] = dotNetRef;
}

export function GetBounds(guid, dotNetRef) {
    let box = document.getElementById(guid);
    let width = box.offsetWidth;
    let height = box.offsetHeight;
    dotNetRef.invokeMethodAsync("SetElementBounds", width, height);
}

window.addEventListener('resize', () => {
    for (const [key, value] of Object.entries(cache)) {
        GetBounds(key, value);
    }
});