
export function GenerateMask(id, mask) {
    var phoneMask = IMask(
        document.getElementById(id), {
        mask: mask
    });
}