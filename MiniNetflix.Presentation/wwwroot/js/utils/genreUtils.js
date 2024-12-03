
const genderSelect = document.getElementById("gender");
const addGender = document.getElementById("addGender");
const genderContainer = document.getElementById("gender-container");
const genreValue = document.querySelectorAll("genre");



//Genre apartado
genderSelect.addEventListener("change", (e) => {

    if (e.target.value == "") {
        addGender.classList.add("hidden");
    }
    else {
        addGender.classList.remove("hidden");
    }
});


addGender.addEventListener("click", (e) => {
    const { value } = genderSelect;
    if (!document.getElementById(`genre-${value}`)) {
        const div = document.createElement("div");
        div.id = `genre-${value}`;
        div.innerHTML = `
            <p class="text-white">${genderSelect.options[genderSelect.selectedIndex].text}</p>
            <button class="btn btn-danger" type="button">
                Remover item
            </button>`;

        const button = div.querySelector("button");
        button.addEventListener("click", () => removeItemFromDOM(value));

        genderContainer.appendChild(div);

        genderSelect.selectedIndex = 0;
        addGender.classList.add("hidden");
    } else {
        alert("Este género ya ha sido añadido.");
    }
});

export function getAllGenres() {
    const genreDivs = genderContainer.children;
    const genres = [];

    for (let div of genreDivs) {
        const id = parseInt(div.id.replace("genre-", ""));
        const p = div.querySelector('p');
        const name = p ? p.textContent : '';
        genres.push({ id, name });
    }
    return genres;
}