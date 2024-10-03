import { createRouter, createWebHistory } from 'vue-router';
import BookDetails from './components/BookDetails.vue';
import CreateBook from './components/CreateBook.vue';
import UpdateBook from './components/UpdateBook.vue';
import GetAllBooks from './components/GetAllBooks.vue';
import DeleteBook from './components/DeleteBook.vue';
import HomePage from './components/HomePage.vue';

const routes = [
  { path: '/', component: HomePage},
  { path: '/getallbooks', component: GetAllBooks },
  { path: '/book/:id', component: BookDetails, props: true },
  { path: '/createbook', component: CreateBook },
  { path: '/books/edit/:id', component: UpdateBook, name: 'updatebook', props: true },
  { path: '/deletebook', component: DeleteBook }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
