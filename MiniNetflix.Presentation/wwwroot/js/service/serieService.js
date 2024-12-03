

export async function createSerie(data) {
    try {

    
    const response = await fetch("https://localhost:7189/Mininetflix/CreatSerie", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    });

    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }

    const responseData = await response.json();
    return responseData;
} catch (error) {
    console.error('Error:', error);
    throw error;  // Rethrow the error after logging it
}
}

export async function updateSerie(data) {

    try {
        const res = await fetch("https://localhost:7189/Mininetflix/PutSerie", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });
        if (!res.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const response = await res.json();
        return response;
    } catch (error) {
        console.error("Error: ", error);
        throw error;
    }

}