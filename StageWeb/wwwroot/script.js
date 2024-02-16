//document.addEventListener('DOMContentLoaded', () => { GetData(); });

let MostraElimina = () => {
        document.getElementById('barra_elimina_libro').hidden = false;
    }

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('elimina_libro').onclick = () => {
        let id = document.getElementById('searchId').value;
        fetch(`/book/${id}`, {
            method: 'DELETE'
        })
            .then(response => {
                if (response.ok) {
                    alert("Libro eliminato con successo");
                } else {
                    alert("Errore durante l'eliminazione del libro");
                }
            });
    }
});


let GetData = () => {
    fetch('/book')
        .then(response => response.json())
        .then(json => addBooksToTable(json));
}

let addBooksToTable = (books) => {
    document.getElementById('tabella').hidden = false;
    return books.map(book => {
        let tr = document.createElement('tr');
        tr.innerHTML = template(book);
        document.getElementById('booksTable').appendChild(tr);
    });
}

let template = (book) => {
    if (!book.id || !book.genre || !book.bookShelf) {
        return `<td>${book.title}</td><td>Id non disponibile</td><td>Genere non disponibile</td><td>Libreria non disponibile</td>`;
    }
    return `<td>${book.title}</td><td>${book.id}</td><td>${book.genre.description}</td><td>${book.bookShelf.code}</td>`;
}


let MostraRicerca = () => {
    document.getElementById('barra_ricerca_id').hidden = false;
}

let SearchById = () => {
let name = document.getElementById('name').value;
    fetch(`/book/${name}`)
        .then(response => response.json())
        .then(json => addBooksToTable(json));
}

let GoBack = () => {
document.getElementById('tabella').hidden = true;
    document.getElementById('booksTable').innerHTML = '';
}

let MostraAggiungi = () => {
    document.getElementById('barra_aggiungi_libro').hidden = false;
}

let AddBook = () => {
    document.getElementById('pulsante_aggiungi').onclick = () => {
        let title = document.getElementById('title').value;
        let idGenre = parseInt(document.getElementById('genre').value);
        let idBookshelf = parseInt(document.getElementById('library').value);

        // Crea gli oggetti Genre e BookShelf
        let genre = { id: idGenre };
        let bookShelf = { id: idBookshelf };

        // Se entrambi gli ID esistono, aggiungi il libro
        fetch('/book', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ title, genre, bookShelf })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Errore durante l\'aggiunta del libro');
                }
                return response.json();
            })
            .then(json => console.log(json))
            .catch(error => alert(error.message));
    }
}


let DeleteBook = () => {
document.getElementById('elimina_libro').onclick = () => {
        let id = document.getElementById('searchId').value;
        fetch(`/book/${id}`, {
            method: 'DELETE'
        })
            .then(response => {
                if (response.ok) {
                    alert("Libro eliminato con successo");
                } else {
                    alert("Errore durante l'eliminazione del libro");
                }
            });
    }
}




