function removeItemFromDOM(id) {
    var element = document.getElementById("genre-" + id);
    if (element) {
        element.remove();
    }
}