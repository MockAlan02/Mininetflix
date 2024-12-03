const Genre = document.getElementById("Genre");
const Production = document.getElementById("Production");
const Search = document.getElementById("Search");

    const MovieContainer = document.getElementById("Movie-Container");

  function fetchMovie(){
      var host = window.location.host; 
      let url = `https://${host}/MiniNetflix/Filter?`
      if (Search.value) {
          url += `Name=${Search.value}`;
      }
    if(Genre.value){
        url += `&Genre=${Genre.value}`;
    }
    if(Production.value){
        url += `&Production=${Production.value}`;
      }
     
      fetch(url)
        .then(response => response.json())
          .then(data => {
              // console.log(data)
             
            //    data.forEach(item => console.log(item))
              const moviesHtml = data.map(item => `
                    <div class="movie-card" onclick=redirectDetail(${item.serie.id})>
                        <img src="${item.serie.imageUrl}" alt="" class="w-full h-full object-cover">
                            <div class="overlay">
                            
                            <ul class="list-disc">
                                <h3 class="text-red-400 text-2xl font-bold mb-4">Genres</h3>
                              ${
                              item.genres.map(it => `<li>${it.genre.name}</li>`).join('')
                              }
                
                            </ul>
                        </div>
                        <p class="text-center font-bold mt-2">${item.serie.name}</p>
                         ${window.location.pathname.toLocaleLowerCase() === "/mininetflix/serie" ? `
                         <button class="btn btn-danger" id="delete-button" onclick="SwapDelete(${item.serie.id})">Delete</button>
                         <button class="btn btn-success" onclick="redirectEdit(${item.serie.id})">Edit</button>
                            ` : ''}
                       
                    </div>
                `).join('');
              
                MovieContainer.innerHTML = moviesHtml;
          
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
  }
Genre.addEventListener("change", fetchMovie);
Production.addEventListener("change", fetchMovie);
Search.addEventListener("input", fetchMovie);