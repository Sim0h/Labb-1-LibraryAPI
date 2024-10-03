<template>
  <div class="update-book">
    <h2>Edit Book</h2>
    <form @submit.prevent="updateBook">
      <div class="form-group">
        <label for="title">Title:</label>
        <input id="title" v-model="book.title" placeholder="Title" required />
      </div>
      <div class="form-group">
        <label for="author">Author:</label>
        <input id="author" v-model="book.author" placeholder="Author" required />
      </div>
      <div class="form-group">
        <label for="publishYear">Publish Year:</label>
        <input id="publishYear" v-model="book.publishYear" type="number" placeholder="Publish Year" />
      </div>
      <div class="form-group">
        <label for="genre">Genre:</label>
        <input id="genre" v-model="book.genre" placeholder="Genre" required />
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <textarea id="description" v-model="book.description" placeholder="Description"></textarea>
      </div>
      <div class="form-group">
        <label>
          Available:
          <input v-model="book.isAvailable" type="checkbox" />
        </label>
      </div>
      <button type="submit" class="update-button">Update Book</button>
      <button type="button" @click="deleteBook" class="delete-button">Delete Book</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "UpdateBook",
  props: ["id"],
  data() {
    return {
      book: {
        title: "",
        author: "",
        publishYear: "",
        genre: "",
        description: "",
        isAvailable: true,
      },
    };
  },
  mounted() {
    this.fetchBook(); // Fetch book data when component is mounted
  },
  methods: {
    async fetchBook() {
      try {
        console.log(`Fetching book with ID: ${this.id}`);
        const response = await axios.get(`/api/book/${this.id}`);
        this.book = response.data.result;
      } catch (error) {
        console.error("Error fetching book:", error);
      }
    },
    updateBook() {
      console.log("Updating book with ID:", this.book.id); // Check ID
      console.log("Updating book with data:", this.book); // Check data
      axios
        .put("/api/updatebook", this.book) // Update URL here
        .then(() => {
          console.log("Book updated successfully");
          alert("Book updated!");
          this.$router.push("/getallbooks");
        })
        .catch((error) => {
          console.error("Error updating book:", error);
        });
    },
    deleteBook() {
      if (confirm("Are you sure you want to delete this book?")) {
        axios
          .delete(`/api/deletebook/${this.book.id}`)
          .then(() => {
            console.log("Book deleted successfully");
            alert("Book deleted!");
            this.$router.push("/getallbooks");
          })
          .catch((error) => {
            console.error("Error deleting book:", error);
          });
      }
    },
  },
};
</script>

<style scoped>
.update-book {
  max-width: 600px;
  margin: 80px auto 0; /* Lägg till tillräckligt med utrymme ovanför */
  padding: 20px;
  border: 1px solid #ddd;
  border-radius: 8px;
  background-color: #f9f9f9;
}

.update-book h2 {
  text-align: center;
  margin-bottom: 20px;
}

.form-group {
  margin-bottom: 15px;
}

.form-group label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

.form-group input,
.form-group textarea {
  width: 100%;
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
}

.form-group textarea {
  resize: vertical;
  height: 100px;
}

button {
  display: block;
  width: 100%;
  padding: 10px;
  border: none;
  border-radius: 4px;
  font-size: 16px;
  cursor: pointer;
  margin-top: 10px;
}

button:hover {
  opacity: 0.8;
}

button.update-button {
  background-color: #007bff;
  color: #fff;
}

button.update-button:hover {
  background-color: #0056b3;
}

button.delete-button {
  background-color: #dc3545;
  color: #fff;
}

button.delete-button:hover {
  background-color: #c82333;
}
</style>

