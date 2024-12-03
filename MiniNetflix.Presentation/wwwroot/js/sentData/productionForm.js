import { updateProduction, createProduction } from "../service/productionService.js"
const form = document.getElementById("form");

form.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(form);
    const method = form.getAttribute('method').toUpperCase();

    const data = {
        name: ""
    }
   
    for (let item of formData.entries()) {
        data[item[0]] = item[1];
    }
   

    if (method === "POST") {
        console.log("hola")
        await createProduction(data);

    } else if (method === "PUT") {
        data["id"] = getIdFromUrl();
        await updateProduction(data);
    }
   
    
})
export function handleSubmitProduction(form) {
    form.addEventListener("submit", async (e) => {
        e.preventDefault();
        const formData = new FormData(form);
        const method = form.getAttribute('method').toUpperCase();

        const data = {
            name: ""
        }

        for (let item of formData.entries()) {
            data[item[0]] = item[1];
        }

        if (method === "POST") {
            await createProduction(data);
        } else if (method === "PUT") {
            data["id"] = getIdFromUrl();
            await updateProduction(data);
        }
    });
}