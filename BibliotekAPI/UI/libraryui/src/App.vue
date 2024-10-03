<template>
  <div id="app">
    <!-- Toolbar -->
    <div class="toolbar">
      <h1>Simon Ståhl Library</h1>
      <nav>
        <router-link to="/">Home</router-link>
        <router-link to="/GetAllBooks">Show All Books</router-link>
        <router-link to="/CreateBook">Add a New Book</router-link>
      </nav>
    </div>

    <!-- Router View -->
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin: 0;
  min-height: 100vh; /* Full height of viewport */
  background: url('@/assets/bokhylla.jpg') no-repeat center center fixed;
  background-size: cover;
}

/* Navbar styling */
.toolbar {
  background-color: #3b5998;
  color: white;
  padding: 10px 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000; /* Ensure navbar is on top */
}

/* Navbar links */
.toolbar nav a {
  color: white;
  text-decoration: none;
  margin: 0 10px;
}

.toolbar nav a:hover {
  text-decoration: underline;
}

/* Body margin adjustment */
body {
  margin: 0; /* Remove any default margin */
  min-height: 100vh; /* Ensure full height */
}
</style>
