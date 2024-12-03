import { createSerie, updateSerie } from "../service/serieService.js";
import { getAllGenres } from "../utils/genreUtils.js"
export default async function handleSubmit(form) {
    const patternUrlYoutube = /^(https?\:\/\/)?(www\.)?(youtube\.com|youtu\.be)(\/.*)?$/;
    const patternUrl = /[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/gi;
    const formData = new FormData(form);
    const method = form.getAttribute("method").toUpperCase();
    const dataObject = {};

    for (let pair of formData.entries()) {
        console.log(pair[0], pair[1]);
        let data = pair[0].charAt(0).toLowerCase() + pair[0].slice(1)
        console.log(data)
        dataObject[data] = pair[1];
    }
    console.log(dataObject)
    dataObject["genresId"] = getAllGenres();

    // More than 1 genre confirmation
    if (!dataObject["genresId"] || dataObject["genresId"].length === 0) {
        alert("Genre cannot be null");
        return false;
    }
    // Youtube URL validator
    
    // Image URL validator
    if (!patternUrl.test(dataObject["imageUrl"])) {
        console.log(dataObject["imageUrl"])
        alert("Insert a valid URL in image URL");
        return false;
    }

    try {
        if (method === "POST") {
            // Save data response
            const response = await createSerie(dataObject);
            if (response) {
                // Alert user
                alert("Your Series Was Added");
                window.location.reload();
            } else {
                alert("Something went wrong");
            }
        } else if (method === "PUT") {
            dataObject["id"] = getIdFromUrl();
            const response = await updateSerie(dataObject);
            if (response) {
                alert("Your Series Was Updated");
                window.location = "/MiniNetflix/serie";
            } else {
                alert("Something went wrong");
            }
        }
    } catch (error) {
        console.error('Failed to process the form:', error);
        alert("An error occurred while processing the form");
    }

    return true;
}
