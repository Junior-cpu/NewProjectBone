namespace Bonepile_New.wwwroot
{

    let buffer = "";

    document.addEventListener("keydown", function (e) {
        if (e.key === "Enter") {
            if (buffer.length > 0) {
                DotNet.invokeMethodAsync("BonePile_New", "ProcessarCodigo", buffer);
                buffer = "";
            }
        } else {
            buffer += e.key;
        }
    });

}
