import "./App.css";
import Blog from "./blog/Blog";
import Img from "./image.png";
import Header from "./blog/Header";

function App() {
  const style = {
    backgroundImage: `url(${Img})`,
  };
  const sections = [
    { title: "Top", url: "#/top" },
    { title: "About", url: "#/about" },
    { title: "Game", url: "#/game" },
    { title: "Technology", url: "#/tech" },
  ];

  return (
    <div className="App" style={style}>
      <header className="header">
        <Header title="LifeGame 3D" sections={sections} />
      </header>
      <header className="App-header">
        <Blog />
      </header>
    </div>
  );
}

export default App;
