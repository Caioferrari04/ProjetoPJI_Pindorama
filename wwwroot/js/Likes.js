let likes = document.getElementsByClassName("like");

for (let i = 0; i < likes.length; i++) {
    likes[i].addEventListener("click", (event) => {
        event.preventDefault();

        let postId = likes[i].id.split("_");
        console.log(postId[1]);
        likes[i].classList.toggle("fa-heart");
        likes[i].classList.toggle("fa-heart-o");
        connection.invoke("likePost", origem, postId[postId.length - 1], !(postId[1] == "c")).catch(function (err) {
            return console.error(err.toString());
        });
    });
}

