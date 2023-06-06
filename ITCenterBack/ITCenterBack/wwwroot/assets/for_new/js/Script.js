document.write("Прив Мир!!!!!!!!!!!!");  
import node-postgres.js;
//const pool = require('./node-postgres');
document.write("333!");  
showComments();

function showComments(comments){
    document.write("Приветrrrrrrrrr Мир!!!!!!!!!!!!");
  let commentSection = document.getElementById("suggestions");
  // for(let i = 0; i < comments.length; i ++){
    for (let i in comments){
    let section = document.createElement("section");
    section.className += "suggestion";
    let heading = document.createElement("h3");
    heading.innerHTML = comments[i].name;
    let comment = document.createElement("p");
    comment.innerHTML = comments[i].comment;
    section.appendChild(heading);
    section.appendChild(comment);
    commentsSection.appendChild(section);
  }
}
