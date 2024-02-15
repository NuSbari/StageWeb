//document.addEventListener('DOMContentLoaded', () => { GetData(); });

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
    return `<td>${book.title}</td><td>${book.genre}</td><td>${book.library}</td>`;
}

let GetDataByName = () => {
    document.getElementById('barra_ricerca_nome').hidden = false;
let name = document.getElementById('name').value;
    fetch(`/book/${name}`)
        .then(response => response.json())
        .then(json => addBooksToTable(json));
}

let GoBack = () => {
document.getElementById('tabella').hidden = true;
    document.getElementById('booksTable').innerHTML = '';
}
