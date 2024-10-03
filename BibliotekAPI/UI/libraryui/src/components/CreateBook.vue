<template>
  <div class="container">
    <header class="header">
      <h2>Add a New Book</h2>
    </header>
    <form @submit.prevent="createBook" class="book-form">
      <div class="form-group">
        <label for="title">Titel</label>
        <input v-model="newBook.title" id="title" placeholder="Titel" required />
      </div>
      <div class="form-group">
        <label for="author">Author</label>
        <input v-model="newBook.author" id="author" placeholder="Författare" required />
      </div>
      <div class="form-group">
        <label for="publishYear">Publish Year</label>
        <input v-model="newBook.publishYear" id="publishYear" type="number" placeholder="Publiceringsår" />
      </div>
      <div class="form-group">
        <label for="genre">Genre</label>
        <input v-model="newBook.genre" id="genre" placeholder="Genre" required />
      </div>
      <div class="form-group">
        <label for="description">Description</label>
        <textarea v-model="newBook.description" id="description" placeholder="Beskrivning"></textarea>
      </div>
      <div class="form-group">
        <label> Available
          <input v-model="newBook.isAvailable" type="checkbox" />
        </label>
      </div>
      <button type="submit" class="submit-button">Add Book</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      newBook: {
        title: '',
        author: '',
        publishYear: '',
        genre: '',
        description: '',
        isAvailable: true
      }
    };
  },
  methods: {
    createBook() {
      axios.post('/api/createbook', this.newBook)
        .then(() => {
          alert('Bok tillagd!');
          this.$router.push('/GetAllBooks'); // Redirect to the list of books
        })
        .catch(error => {
          console.error('Error creating book:', error);
        });
    }
  }
};
</script>

<style scoped>
/* Ensure background image covers entire page */
html, body {
  margin: 0;
  padding: 0;
  height: 100%;
}

.container {
  padding: 20px;
  background: url('@/assets/bokhylla.jpg') no-repeat center center/cover;
  min-height: 100vh;
}

.header {
  background-color: rgba(0, 0, 0, 0.6); /* Dark semi-transparent background */
  color: #fff;
  padding: 20px;
  text-align: center;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px; /* Space below header */
}

.book-form {
  background: #fff;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  padding: 20px;
  width: 100%;
  max-width: 800px;
  margin: 0 auto; /* Center the form horizontally */
}

.form-group {
  margin-bottom: 15px;
}

.form-group label {
  display: block;
  font-weight: bold;
  margin-bottom: 5px;
}

.form-group input,
.form-group textarea {
  width: 100%;
  padding: 10px;
  border: 1px solid #ddd;
  border-radius: 4px;
  box-sizing: border-box;
}

.form-group textarea {
  height: 100px;
}

.submit-button {
  background-color: #007bff;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
  transition: background-color 0.3s ease;
}

.submit-button:hover {
  background-color: #0056b3;
}
</style>
