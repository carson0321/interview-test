# Interview test

Merge **Project-A** into **Project-B**

```bash
cd path/to/project-b
git remote add project-a path/to/project-a
git fetch project-a
git merge --allow-unrelated-histories project-a/master
git remote remove project-a
```

P.S. The ```--allow-unrelated-histories``` parameter only exists since git >= 2.9
