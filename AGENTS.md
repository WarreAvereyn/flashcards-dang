# AGENTS.md — working rules for Paseo agents on this repo

## Branching model

- `main` — stable. **Never** commit or push here. **Never** open PRs against it.
- `develop` — integration branch. This is where all agent work lands, via PR.
- Agent branches — Paseo-created worktrees/branches spring from `develop`.

## What agents MAY do

- Create branches from `develop` (via Paseo worktrees or `git worktree add`).
- Commit freely on those branches.
- Push their own agent branches to GitHub (`git push <remote> <branch>`).
- Create pull requests **with base = `develop`** (the local `gh` shim enforces
  this: `gh pr create` without `--base` targets develop; any other base is
  refused).

## What agents MUST NOT do

- Open PRs targeting anything but `develop` (including `main`).
- Push to `main` or `develop` directly.
- Force-push (`--force`) anywhere.
- Bypass or edit the `gh` shim at `~/.local/bin/gh`.
- Change GitHub repo settings, branch protection, or workflow files that gate
  merging.

## After your PR is opened

Stop there. A human reviews the PR on GitHub. Do not chase merges, do not
merge your own PRs, and do not create follow-up PRs stacked on the first one
unless asked.

## Conventions

- Write clear commit messages; one logical change per commit.
- Keep PRs small and single-purpose; split anything sprawling.
