

// 1 menu desplegado
// 0 menu cerrado
var estatusMenu = 0
export function menu() {

    if (estatusMenu) {
        $('.menuPrincipal').css('width', '60px');
        $('.menuOpciones').hide();
        $('.botonCerrar').css('margin-left', '-5px');
        $('.iconoPequeno').show();
        $('.iconoGrande').hide();
        estatusMenu = 0;
    } else {
        $('.menuPrincipal').css('width', '250px');
        $('.menuOpciones').show();
        $('.botonCerrar').css('margin-left', '150px');

        $('.iconoPequeno').hide();
        $('.iconoGrande').show();
        estatusMenu = 1;
    }



};
