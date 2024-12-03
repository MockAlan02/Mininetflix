import { updateGenre, createGenre } from "../service/genreService.js"
const form = document.getElementById("form");

const objSent = {
    name: ""
}
form.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(form);
    const method = form.getAttribute("method").toUpperCase();
   

    for (let pair of formData.entries()) {
        objSent[pair[0]] = pair[1];
    }

    if (method === "POST") {
        await createGenre(objSent);
    } else if (method === "PUT") {
        objSent["id"] = getIdFromUrl();
        await updateGenre(objSent);
    }
})

export function handleSubmitGenre(form) {
    form.addEventListener("submit", async (e) => {
        e.preventDefault();
        const formData = new FormData(form);
        const method = form.getAttribute("method").toUpperCase();
        const objSent = {};

        for (let pair of formData.entries()) {
            let data = pair[0].charAt(0).toLowerCase() + pair[0].slice(1)
            objSent[data] = pair[1];
        }

        if (method === "POST") {
            await createGenre(objSent);
        } else if (method === "PUT") {
            objSent["id"] = getIdFromUrl();
            await updateGenre(objSent);
        }
    });
}
