import Grid from "@material-ui/core/Grid";
import FeaturedPost from "./FeaturedPost";

const featuredPosts = [
  {
    title: "What's lifegame ?",
    date: "　",
    description:
      "This is a wider card with supporting text below as a natural lead-in to additional content.",
    image:
      "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTbihgOPtSQt7T3Rro-H9T-YcIb1S8jxR43dYVmIcTrfTxkpL1Dc2NJ29U7VhMhhN5u4Nk&usqp=CAU",
    imageText: "Image Text",
    url: "#/about",
    linkText: "Continue reading...",
  },
  {
    title: "Visit lifegame world...",
    date: "　",
    description:
      "This is a wider card with supporting text below as a natural lead-in to additional content.",
    image:
      "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTbihgOPtSQt7T3Rro-H9T-YcIb1S8jxR43dYVmIcTrfTxkpL1Dc2NJ29U7VhMhhN5u4Nk&usqp=CAU",
    imageText: "Image Text",
    url: "#/game",
    linkText: "Let's start...",
  },
];

function Top() {
  return (
    <Grid container spacing={4}>
      {featuredPosts.map((post) => (
        <FeaturedPost key={post.title} post={post} />
      ))}
    </Grid>
  );
}

export default Top;
