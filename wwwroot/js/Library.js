let games = document.getElementsByClassName("game");
let popups = document.getElementsByClassName("popup");

for (let i = 0; i < games.length; i++) {
    games[i].addEventListener("click", (event) => {
        event.preventDefault();
        for (let j = 0; j < games.length; j++) {
            popups[j].classList = "popup not-visible";
        }
        popups[i].classList.toggle("not-visible");
    })
}