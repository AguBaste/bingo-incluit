

let parrafo = document.getElementById('parrafo');

const numeros = [];

for (let index = 0; index < 90; index++) {
  numeros[index] = index + 1;
}

numeros.sort(()=>Math.random()-0.5);
let indice = 0;

function Sorteo() {
  while (indice < 90) {
    parrafo.innerHTML = numeros[indice];
    indice++;
    return numeros[indice];
  }
  parrafo.innerHTML = "Se acabaron los numeros";
}
console.log(numeros);
