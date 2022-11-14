
const sortear = document.getElementById('sortear');
let parrafo = document.getElementById('parrafo');
function Sorteo() {
    var numero = parseInt(Math.random() * 100);

    console.log(numero);
    parrafo.innerHTML = numero;
}