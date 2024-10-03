<template>
    <div class="home-page">
      <header class="hero-section">
        <h1>Welcome to my Library!</h1>
        <p>Here you can explore and manage my book collection.</p>
        <router-link to="/GetAllBooks" class="btn">Show All Books</router-link>
      </header>
    </div>
  </template>
  
  <style scoped>
  .home-page {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh; /* Full height of viewport */
    background: url('@/assets/bokhylla.jpg') no-repeat center center/cover;
    text-align: center;
    color: #fff;
    margin: 0;
  }
  
  .hero-section {
    background: rgba(0, 0, 0, 0.5); /* Semi-transparent background for text */
    padding: 40px;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
  }
  
  .home-page h1 {
    font-size: 2.5em;
    margin-bottom: 20px;
  }
  
  .home-page p {
    font-size: 1.2em;
    margin-bottom: 30px;
  }
  
  .btn {
    display: inline-block;
    padding: 12px 25px;
    font-size: 1.1em;
    color: #fff;
    background-color: #007bff;
    text-decoration: none;
    border-radius: 5px;
    transition: background-color 0.3s ease, transform 0.3s ease;
  }
  
  .btn:hover {
    background-color: #0056b3;
    transform: scale(1.05);
  }
  </style>
  