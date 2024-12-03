

export async function updateGenre(data) {
 
    fetch("https://localhost:7189/Genre/UpdateGenre", {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data) 
    })
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error('Error:', error));

} 

export async function createGenre(data) {
    console.log(data);
    fetch("https://localhost:7189/Genre/CreateGenre", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => response.text())
        .then(data => console.log(data))
        .catch(error => console.error('Error:', error));
}
