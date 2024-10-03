module.exports = {
  transpileDependencies: true,
  devServer: {
    proxy: {
      '/api': {
        target: 'https://localhost:7034',  
        changeOrigin: true,                 
        secure: false,                       
      }
    }
  }
};
