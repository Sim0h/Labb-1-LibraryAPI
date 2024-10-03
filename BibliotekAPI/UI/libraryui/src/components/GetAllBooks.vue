<template>
  <div class="container">
    <header class="header">
      <h1>All Books in the Library</h1>
      <!-- Search bar -->
      <input
        v-model="searchQuery"
        @input="filterBooks"
        class="search-input"
        placeholder="Search by title, author, or genre"
      />
    </header>
    <div v-if="filteredBooks.length" class="book-list">
      <div v-for="book in filteredBooks" :key="book.id" class="book-card">
        <div
          class="availability-indicator"
          :class="{
            available: book.isAvailable,
            unavailable: !book.isAvailable,
          }"
        >
          <span class="tooltip">{{
            book.isAvailable ? "Available" : "Unavailable"
          }}</span>
        </div>
        <h2>{{ book.title }}</h2>
        <p><strong>Author:</strong> {{ book.author }}</p>
        <p><strong>Publish Year:</strong> {{ book.publishYear }}</p>
        <p><strong>Genre:</strong> {{ book.genre }}</p>
        <button class="description-button" @click="showDescription(book)">
          Description
        </button>
        <router-link
          :to="{ name: 'updatebook', params: { id: book.id } }"
          class="edit-button"
          >Edit</router-link
        >
      </div>
    </div>
    <p v-else class="loading">Couldn't find any books</p>

    <!-- Modal for showing book description -->
    <div v-if="showModal" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeModal">&times;</span>
        <h2>{{ currentBook.title }}</h2>
        <p><strong>Author:</strong> {{ currentBook.author }}</p>
        <p><strong>Publish Year:</strong> {{ currentBook.publishYear }}</p>
        <p><strong>Description:</strong> {{ currentBook.description }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "GetAllBooks",
  data() {
    return {
      books: [],
      searchQuery: "",
      showModal: false,
      currentBook: null,
    };
  },
  computed: {
    filteredBooks() {
      const query = this.searchQuery.toLowerCase();
      return this.books.filter((book) => {
        return (
          book.title.toLowerCase().includes(query) ||
          book.author.toLowerCase().includes(query) ||
          book.genre.toLowerCase().includes(query)
        );
      });
    },
  },
  mounted() {
    this.fetchBooks();
  },
  methods: {
    async fetchBooks() {
      try {
        const response = await axios.get("/api/books");
        this.books = response.data.result;
      } catch (error) {
        console.error("Error fetching books:", error);
      }
    },
    showDescription(book) {
      this.currentBook = book;
      this.showModal = true;
    },
    closeModal() {
      this.showModal = false;
      this.currentBook = null;
    },
    filterBooks() {
      
    },
  },
};
</script>

<style scoped>

.container {
  margin-top: 80px; 
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
}

/* Header styling */
.header {
  background-color: rgba(0, 0, 0, 0.6); 
  color: #fff;
  padding: 20px;
  text-align: center;
  z-index: 500; 
}

/* Search input styling */
.search-input {
  margin-top: 15px;
  padding: 8px;
  font-size: 16px;
  border: 1px solid #ddd;
  border-radius: 5px;
  width: 100%;
  max-width: 400px;
  display: inline-block;
}

/* Flexbox for card layout */
.book-list {
  display: flex;
  flex-wrap: wrap;
  gap: 20px;
  justify-content: center;
}

/* Book card styling */
.book-card {
  background: #fff;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  padding: 20px;
  width: 280px;
  text-align: left;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  position: relative; 
}

/* Hover effect */
.book-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
}

.book-card .description-button {
  display: block;
  margin: 10px 0;
  padding: 10px;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  text-align: center;
  text-decoration: none;
}

.book-card .edit-button {
  display: block;
  padding: 10px;
  background-color: #28a745;
  color: #fff;
  border: none;
  border-radius: 5px;
  text-align: center;
  text-decoration: none;
  margin-top: 10px;
}

.book-card .availability-indicator {
  position: absolute;
  top: 10px;
  right: 10px;
  width: 20px;
  height: 20px;
  border-radius: 50%;
  background-color: #dc3545; 
  display: flex;
  align-items: center;
  justify-content: center;
  color: #fff;
}

.book-card .availability-indicator.available {
  background-color: #28a745; 
}

.book-card .availability-indicator.unavailable {
  background-color: #dc3545; 
}

.book-card .tooltip {
  display: none;
  position: absolute;
  top: 25px;
  left: 50%;
  transform: translateX(-50%);
  background: #333;
  color: #fff;
  padding: 5px 10px;
  border-radius: 4px;
  font-size: 12px;
  white-space: nowrap;
}

.book-card .availability-indicator:hover .tooltip {
  display: block;
}

.modal {
  position: fixed;
  z-index: 1000;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  overflow: auto;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
}

.modal-content {
  background-color: #fff;
  border-radius: 8px;
  width: 80%;
  max-width: 600px;
  padding: 20px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  position: relative;
}

.close {
  color: #aaa;
  font-size: 24px;
  position: absolute;
  top: 10px;
  right: 20px;
  cursor: pointer;
}

.close:hover {
  color: #000;
}

.loading {
  font-size: 1.5rem;
  text-align: center;
  margin: 20px 0;
}
</style>
