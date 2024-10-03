<template>
    <div>
      <button @click="deleteBook(bookId)">Ta bort bok</button>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    props: {
      bookId: {
        type: Number,
        required: true
      }
    },
    methods: {
      deleteBook(id) {
        axios.delete(`https://localhost:7034/api/deletebook/${id}`)
          .then(() => {
            alert('Bok borttagen!');
          })
          .catch(error => {
            console.error('Error deleting book:', error);
          });
      }
    }
  };
  </script>
  