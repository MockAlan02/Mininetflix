import { createSerie, updateSerie } from "../service/serieService.js";
import { getAllGenres } from "../utils/genreUtils.js"
const form = document.getElementById("form");






form.addEventListener("submit", async (e) => {
    e.preventDefault();
    const patternUrlYoutube = /^(https?\:\/\/)?(www\.)?(youtube\.com|youtu\.be)(\/.*)?$/;
    const patternUrl = /[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/gi;
    const formData = new FormData(form);
    const method = form.getAttribute("method").toUpperCase();
    const dataObject = {};

    for (let pair of formData.entries()) {
        console.log(pair[0], pair[1]);
        dataObject[pair[0]] = pair[1];
    }

    dataObject["genresId"] = getAllGenres();

        //More than 1 genre confirmation
    if (!dataObject["genresId"] || dataObject["genresId"].length === 0) {
        alert("Genre can not be null");
        return;
    }
        //Youtube url validator
    if (!patternUrlYoutube.test(dataObject["linkVideo"])) {
        alert("Insert a valid url in link video");
        return;
    }
        //Image Url validator
    if (!patternUrl.test(dataObject["imageUrl"])) {
        alert("Insert a valid url in image url");
        return;
    }

    if (method === "POST") {

        //save data response
        const response = await createSerie(dataObject);
        if (response) {
            //alert user
            alert("Your Movie Was Added");
            window.location.reload();
        } else {
            alert("something went wrong")
        }
    } else if (method === "PUT") {
        dataObject["id"] = getIdFromUrl();
        const response = await updateSerie(dataObject);
        if (response) {
            alert("Your Movie Was Updated");
            window.location = "/MiniNetflix/serie";
        } else {
            alert("something went wrong")
        }
    }
});