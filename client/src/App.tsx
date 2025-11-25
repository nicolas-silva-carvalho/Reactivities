import { useEffect, useState } from "react";
import axios from "axios";
import { List, ListItem, ListItemText, Typography } from "@mui/material";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios
      .get<Activity[]>("https://localhost:5001/api/activities")
      .then((response) => setActivities(response.data));
  }, []);
  return (
    <>
      <Typography variant="h3">Reactivities</Typography>

      {activities.map((activitie) => (
        <List>
          <ListItem key={activitie.id}>
            <ListItemText>{activitie.title}</ListItemText>
          </ListItem>
        </List>
      ))}
    </>
  );
}

export default App;
